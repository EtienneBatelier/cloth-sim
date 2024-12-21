TEMPLATE = lib

CONFIG = staticlib c++11

SOURCES += \
    Dessinable.cc \
    Integrateur.cc \
    IntegrateurEuler.cc \
    Masse.cc \
    Ressort.cc \
    SupportADessin.cc \
    Systeme.cc \
    Tissu.cc \
    Vecteur3D.cc

HEADERS += \
    Integrateur.h \
    IntegrateurEuler.h \
    Masse.h \
    Ressort.h \
    SupportADessin.h \
    Systeme.h \
    Tissu.h \
    Vecteur3D.h \
    Dessinable.h

OTHER_FILES += \
    general.pro.user
