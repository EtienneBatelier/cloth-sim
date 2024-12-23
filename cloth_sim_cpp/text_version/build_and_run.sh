g++ -c ./*.cpp
g++ -c ./*.cc
g++ -o text_version ./*.o
rm ./*.o
./text_version