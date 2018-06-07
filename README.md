BDInfoCLI-ng
======

Original source origin: http://www.cinemasquid.com/blu-ray/tools/bdinfo

BDInfoCLI-ng forked from: https://github.com/UniqProject/BDInfo

Additional sources from BDInfoCLI (https://github.com/Tripplesixty/BDInfoCLI)

BDInfoCLI-ng is the latest BDInfo (with UHD support) modified for use as a CLI utility. BDInfoCLI-ng implements an interface similar to BDInfoCLI, but on the latest BDInfo code base and with code changes designed to be as minimally invasive as possible for easier maintainability with BDInfo updates.

Usage
======
```
BDInfo.exe <BD_FOLDER> [REPORT_DEST]
  -?, --help, -h             Print out the options.
  -l, --list                 Print the list of playlists.
  -m, --mpls=VALUE           Comma separated list of playlists to scan.
  -w, --whole                Scan whole disc - every playlist.
  -v, --version              Print the version.
```

#### Examples
```
# Display playlists in given disc, prompt user to select playlists
# to scan, and output the generated report to the same disc path:
BDInfo.exe PATH_CONTAINING_BDMV

# Same as above, but output report in given report folder:
BDInfo.exe PATH_CONTAINING_BDMV REPORT_OUTPUT_DIR

# Just display the list of playlists in the given disc:
BDInfo.exe -l PATH_CONTAINING_BDMV

# Scan the whole disc (every playlist) and write report to disc folder (non-interactive):
BDInfo.exe -w PATH_CONTAINING_BDMV

# Scan selected playlists and write report to disc folder (non-interactive):
BDInfo.exe -m 00006.MPLS,00009.MPLS PATH_CONTAINING_BDMV

# Display the BDInfo version this build of BDInfoCLI-ng is based on:
BDInfo.exe -v
```

Windows
======
##### Requirements
<ul>
<li>Windows Vista, Windows 7 or higher Operating System</li>
<li>.NET Framework 4.5 or Higher</li>
<li>Source Code</li>
</ul>

BDInfoCLI-ng can be built using the free tool <a href="https://www.visualstudio.com/vs/community/">Microsoft Visual Studio Community Edition</a>. Just install Visual Studio, open ```BDInfo.sln```, and build.


Linux
======
BDInfoCLI-ng can be built and run with <a href="https://www.mono-project.com/">Mono</a>.

Using Docker is highly recommend (nobody should have to taint their OS with Mono).

To do so install Docker and then simply use the included ``bdinfo`` wrapper script. The wrapper script automatically handles mounting the necessary directories into the container. The first run will be slow as the container image will have to be downloaded, subsequent runs will not be.

Wrapper script example:
```
./bdinfo --help
```

Alternatively, you can build and run the Docker container yourself, e.g:
```
docker build -t bdinfocli-ng .
docker run --rm --it -v <host_dir>:/mnt /mnt/disc
```

Mac
======
The above instructions for using BDInfoCLI-ng with Docker on Linux should also work for Macs, but it has not been tested.
