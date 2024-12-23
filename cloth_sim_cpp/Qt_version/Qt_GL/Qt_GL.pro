QT += widgets
QT += openglwidgets
QT += core
CONFIG += c++11

TARGET = projet

INCLUDEPATH = ../general

SOURCES += \
    main_qt_gl.cc \
    glwidget.cc \
    vue_opengl.cc \

HEADERS += \
    glwidget.h \
    vertex_shader.h \
    vue_opengl.h \

RESOURCES += \
    resource.qrc
