CXX = g++
CC  = $(CXX)

CXXFLAGS = -std=c++11  # C++11

BASE_OBJS =  TextViewer.o Systeme.o Dessinable.o SupportADessin.o Tissu.o IntegrateurEuler.o Integrateur.o Ressort.o Masse.o Vecteur3D.o
HEADERS = $(wildcard *.h)
SRC = $(wildcard *.cc)
BASE = $(BASE_OBJS) $(HEADERS) $(SRC)

all: Exercicep10

Exercicep10: $(BASE)
	$(CC) $(CXXFLAGS) -o $@ $@.cc $(BASE_OBJS)
	

clean:
	rm -rf *.o

