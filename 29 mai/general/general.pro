TEMPLATE = lib

CONFIG = staticlib c++11

SOURCES += \
    Dessinable.cc \
    Integrateur.cc \
    Masse.cc \
    Ressort.cc \
    SupportADessin.cc \
    Systeme.cc \
    Tissu.cc \
    Vecteur3D.cc \
    TissuRectangle.cpp \
    Contrainte.cpp \
    Crochet.cpp \
    Impulsion.cpp \
    ImpulsionSinusoidale.cpp \
    TissuDisque.cc \
    TissuChaine.cc \
    IntegrateurEuler.cc \
    TissuCompose.cc \
    integrateurnewmark.cpp

HEADERS += \
    Integrateur.h \
    IntegrateurEuler.h \
    Masse.h \
    Ressort.h \
    SupportADessin.h \
    Systeme.h \
    Tissu.h \
    Vecteur3D.h \
    Dessinable.h \
    TissuRectangle.h \
    Contrainte.h \
    Crochet.h \
    Impulsion.h \
    ImpulsionSinusoidale.h \
    TissuDisque.h \
    TissuChaine.h \
    TissuCompose.h \
    integrateurnewmark.h

OTHER_FILES += \
    general.pro.user
