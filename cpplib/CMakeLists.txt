cmake_minimum_required (VERSION 3.8)

project(cpplib)
set(CMAKE_CXX_FLAGS "-m64") 

add_library(cpplib SHARED Cpp.cpp)
target_link_libraries(cpplib)