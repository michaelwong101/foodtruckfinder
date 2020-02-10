FROM mono:onbuild
CMD [ "nuget", "restore ./foodtruckfinder.sln"]
CMD [ "msbuild", "./foodtruckfinder.sln"]
CMD [ "mono",  "./foodtruckfinder/bin/Debug/foodtruckfinder.exe" ]