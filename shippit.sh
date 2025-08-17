rm -rf ./pub-html
dotnet publish ./src/TGGDGGJ2/TGGDGGJ2.csproj -o ./pub-html -c Release 
rm -f ./pub-html/*.pdb
butler push pub-html/wwwroot thegrumpygamedev/tggd-ggj2:html
