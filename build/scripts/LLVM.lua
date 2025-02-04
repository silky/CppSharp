require "Build"
require "Utils"
require "../Helpers"

local llvm = basedir .. "/../deps/llvm"

-- If we are inside vagrant then clone and build LLVM outside the shared folder,
-- otherwise file I/O performance will be terrible.
if is_vagrant() then
	llvm = os.getenv("HOME") .. "/llvm"
end

local llvm_build = llvm .. "/" .. os.get()

function get_llvm_rev()
	return cat(basedir .. "/LLVM-commit")
end

function get_clang_rev()
	return cat(basedir .. "/Clang-commit")
end

function clone_llvm()
  local llvm_release = get_llvm_rev()
  print("LLVM release: " .. llvm_release)

  local clang_release = get_clang_rev()
  print("Clang release: " .. clang_release)

  if os.isdir(llvm) and not os.isdir(llvm .. "/.git") then
    error("LLVM directory is not a git repository.")
  end

  if not os.isdir(llvm) then
    git.clone(llvm, "http://llvm.org/git/llvm.git")
  else
    git.reset_hard(llvm, "HEAD")
    git.pull_rebase(llvm)
  end

  local clang = llvm .. "/tools/clang"
  if not os.isdir(clang) then
    git.clone(clang, "http://llvm.org/git/clang.git")
  else
    git.reset_hard(clang, "HEAD")
    git.pull_rebase(clang)
  end

  git.reset_hard(llvm, llvm_release)
  git.reset_hard(clang, clang_release)
end

function get_llvm_package_name(rev, conf)
  if not rev then
  	rev = get_llvm_rev()
  end
  if not conf then
  	conf = get_llvm_configuration_name()
  end

  rev = string.sub(rev, 0, 6)
  return table.concat({"llvm", rev, os.get(), conf}, "-")
end

function get_llvm_configuration_name()
	return os.is("windows") and "RelWithDebInfo" or "Release"
end

function extract_7z(archive, dest_dir)
	return execute(string.format("7z x %s -o%s -y", archive, dest_dir), true)
end

function extract_tar_xz(archive, dest_dir)
	execute("mkdir -p " .. dest_dir, true)
	return execute(string.format("tar xJf %s -C %s", archive, dest_dir), true)
end

local use_7zip = os.is("windows")
local archive_ext = use_7zip and ".7z" or ".tar.xz"

function download_llvm()
  local base = "https://dl.dropboxusercontent.com/u/194502/CppSharp/llvm/"
  local pkg_name = get_llvm_package_name()
  local archive = pkg_name .. archive_ext

  -- check if we already have the file downloaded
  if not os.isfile(archive) then
	  download(base .. archive, archive)
  end

  -- extract the package
  if not os.isdir(pkg_name) then
  	if use_7zip then
  		extract_7z(archive, pkg_name)
  	else
  		extract_tar_xz(archive, pkg_name)
  	end
  end
end

function cmake(gen, conf, options)
	local cwd = os.getcwd()
	os.chdir(llvm_build)
	local cmd = "cmake -G " .. '"' .. gen .. '"'
		.. ' -DCLANG_BUILD_EXAMPLES=false '
		.. ' -DCLANG_INCLUDE_DOCS=false '
		.. ' -DCLANG_INCLUDE_TESTS=false'
		.. ' -DCLANG_ENABLE_ARCMT=false'
		.. ' -DCLANG_ENABLE_STATIC_ANALYZER=false'
 		.. ' -DLLVM_INCLUDE_EXAMPLES=false '
 		.. ' -DLLVM_INCLUDE_DOCS=false '
 		.. ' -DLLVM_INCLUDE_TESTS=false'
		.. ' -DLLVM_TOOL_BUGPOINT_BUILD=false'
 		.. ' -DLLVM_TOOL_BUGPOINT_PASSES_BUILD=false'
 		.. ' -DLLVM_TOOL_CLANG_TOOLS_EXTRA_BUILD=false'
 		.. ' -DLLVM_TOOL_COMPILER_RT_BUILD=false'
 		.. ' -DLLVM_TOOL_DRAGONEGG_BUILD=false'
 		.. ' -DLLVM_TOOL_DSYMUTIL_BUILD=false'
 		.. ' -DLLVM_TOOL_GOLD_BUILD=false'
 		.. ' -DLLVM_TOOL_LLC_BUILD=false'
 		.. ' -DLLVM_TOOL_LLDB_BUILD=false'
 		.. ' -DLLVM_TOOL_LLD_BUILD=false'
 		.. ' -DLLVM_TOOL_LLGO_BUILD=false'
 		.. ' -DLLVM_TOOL_LLI_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_AR_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_AS_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_AS_FUZZER_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_BCANALYZER_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_CONFIG_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_COV_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_CXXDUMP_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_C_TEST_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_DIFF_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_DIS_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_DWARFDUMP_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_EXTRACT_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_GO_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_JITLISTENER_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_LINK_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_LTO_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_MCMARKUP_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_MC_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_MC_FUZZER_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_NM_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_OBJDUMP_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_PDBDUMP_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_PROFDATA_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_READOBJ_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_RTDYLD_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_SHLIB_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_SIZE_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_SPLIT_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_STRESS_BUILD=false'
 		.. ' -DLLVM_TOOL_LLVM_SYMBOLIZER_BUILD=false'
 		.. ' -DLLVM_TOOL_LTO_BUILD=false'
 		.. ' -DLLVM_TOOL_MSBUILD_BUILD=false'
 		.. ' -DLLVM_TOOL_OBJ2YAML_BUILD=false'
 		.. ' -DLLVM_TOOL_OPT_BUILD=false'
 		.. ' -DLLVM_TOOL_SANCOV_BUILD=false'
 		.. ' -DLLVM_TOOL_VERIFY_USELISTORDER_BUILD=false'
 		.. ' -DLLVM_TOOL_XCODE_TOOLCHAIN_BUILD=false'
 		.. ' -DLLVM_TOOL_YAML2OBJ_BUILD=false'
		.. ' -DCLANG_TOOL_ARCMT_TEST_BUILD=false'
 		.. ' -DCLANG_TOOL_CLANG_CHECK_BUILD=false'
 		.. ' -DCLANG_TOOL_CLANG_FORMAT_BUILD=false'
 		.. ' -DCLANG_TOOL_CLANG_FORMAT_VS_BUILD=false'
 		.. ' -DCLANG_TOOL_CLANG_FUZZER_BUILD=false'
 		.. ' -DCLANG_TOOL_C_ARCMT_TEST_BUILD=false'
 		.. ' -DCLANG_TOOL_C_INDEX_TEST_BUILD=false'
 		.. ' -DCLANG_TOOL_DIAGTOOL_BUILD=false'
 		.. ' -DCLANG_TOOL_DRIVER_BUILD=false'
 		.. ' -DCLANG_TOOL_LIBCLANG_BUILD=false'
 		.. ' -DCLANG_TOOL_SCAN_BUILD_BUILD=false'
 		.. ' -DCLANG_TOOL_SCAN_VIEW_BUILD=false'
 		.. ' -DLLVM_TARGETS_TO_BUILD="X86"'
 		.. ' -DCMAKE_BUILD_TYPE=' .. conf .. ' ..'
 		.. ' ' .. options
 	execute(cmd)
 	os.chdir(cwd)
end

function clean_llvm(llvm_build)
	if os.isdir(llvm_build) then os.rmdir(llvm_build) end
	os.mkdir(llvm_build)
end

function build_llvm(llvm_build)
	local conf = get_llvm_configuration_name()
	local use_msbuild = false
	if os.is("windows") and use_msbuild then
		cmake("Visual Studio 12 2013", conf)
		local llvm_sln = path.join(llvm_build, "LLVM.sln")
		msbuild(llvm_sln, conf)
	else
		local options = os.is("macosx") and
			"-DLLVM_ENABLE_LIBCXX=true -DLLVM_BUILD_32_BITS=true" or "" 
		cmake("Ninja", conf, options)
		ninja(llvm_build)
		ninja(llvm_build, "clang-headers")
	end
end

function package_llvm(conf, llvm, llvm_build)
	local rev = git.rev_parse(llvm, "HEAD")
	if string.is_empty(rev) then
		rev = get_llvm_rev()
	end

	local out = get_llvm_package_name(rev, conf)

	if os.isdir(out) then os.rmdir(out)	end
	os.mkdir(out)

	os.copydir(llvm .. "/include", out .. "/include")
	os.copydir(llvm_build .. "/include", out .. "/build/include")

	local llvm_msbuild_libdir = "/" .. conf .. "/lib"
	local lib_dir =  os.is("windows") and os.isdir(llvm_msbuild_libdir)
		and llvm_msbuild_libdir or "/lib"
	local llvm_build_libdir = llvm_build .. lib_dir

	if os.is("windows") and os.isdir(llvm_build_libdir) then
		os.copydir(llvm_build_libdir, out .. "/build" .. lib_dir, "*.lib")
	else
		os.copydir(llvm_build_libdir, out .. "/build/lib", "*.a")
	end

	os.copydir(llvm .. "/tools/clang/include", out .. "/tools/clang/include")
	os.copydir(llvm_build .. "/tools/clang/include", out .. "/build/tools/clang/include")

	os.copydir(llvm .. "/tools/clang/lib/CodeGen", out .. "/tools/clang/lib/CodeGen", "*.h")
	os.copydir(llvm .. "/tools/clang/lib/Driver", out .. "/tools/clang/lib/Driver", "*.h")

	local out_lib_dir = out .. "/build" .. lib_dir
	if os.is("windows") then
		os.rmfiles(out_lib_dir, "LLVM*ObjCARCOpts*.lib")
		os.rmfiles(out_lib_dir, "clang*ARC*.lib")
		os.rmfiles(out_lib_dir, "clang*Matchers*.lib")
		os.rmfiles(out_lib_dir, "clang*Rewrite*.lib")
		os.rmfiles(out_lib_dir, "clang*StaticAnalyzer*.lib")
		os.rmfiles(out_lib_dir, "clang*Tooling*.lib")		
	else
		os.rmfiles(out_lib_dir, "libllvm*ObjCARCOpts*.a")
		os.rmfiles(out_lib_dir, "libclang*ARC*.a")
		os.rmfiles(out_lib_dir, "libclang*Matchers*.a")
		os.rmfiles(out_lib_dir, "libclang*Rewrite*.a")
		os.rmfiles(out_lib_dir, "libclang*StaticAnalyzer*.a")
		os.rmfiles(out_lib_dir, "libclang*Tooling*.a")
	end

	return out
end

function archive_llvm(dir)
	local archive = dir .. archive_ext
	if os.isfile(archive) then os.remove(archive) end
	local cwd = os.getcwd()
	os.chdir(dir)
	if use_7zip then
		execute("7z a " .. path.join("..", archive) .. " *")
	else
		execute("tar cJf " .. path.join("..", archive) .. " *")
	end
	os.chdir(cwd)
	if is_vagrant() then
		os.copyfile(archive, "/cppsharp")
	end
end

if _ACTION == "clone_llvm" then
  clone_llvm()
  os.exit()
end

if _ACTION == "build_llvm" then
	clean_llvm(llvm_build)
	build_llvm(llvm_build)
  os.exit()
end

if _ACTION == "package_llvm" then
	local conf = get_llvm_configuration_name()
	local pkg = package_llvm(conf, llvm, llvm_build)
	archive_llvm(pkg)
  os.exit()
end

if _ACTION == "download_llvm" then
  download_llvm()
  os.exit()
end

