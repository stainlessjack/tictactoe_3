# Build Unity project
/Applications/Unity/Hub/Editor/2022.2.0b16/Unity.app/Contents/MacOS/Unity -batchmode -projectPath $(pwd) -logFile $(pwd)/unity.log -executeMethod GameBuilder.BuildMacOS -quit

# Generate new game manifest
/Applications/Unity/Hub/Editor/2022.2.0b16/Unity.app/Contents/MacOS/Unity -batchmode -projectPath $(pwd) -logFile $(pwd)/unity.log -executeMethod GameBuilder.GenerateManifest -quit

# Upload new version of the game to the server
scp -rvCp $(pwd)/Builds/MacOS/tictactoe.app root@144.202.111.41:/var/www/html/active/

# Upload the contents of the Assets folder to the server
scp -rvCp $(pwd)/Assets root@144.202.111.41:/var/www/html/active/

# Upload the matching game.manifest to the server
scp -rvCp $(pwd)/game.manifest root@144.202.111.41:/var/www/html/active/