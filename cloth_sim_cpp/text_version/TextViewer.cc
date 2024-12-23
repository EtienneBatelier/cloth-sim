#include "TextViewer.h"
#include "Systeme.h"

using namespace std;

//Constructeur
TextViewer::TextViewer(ostream& flot_)
:flot(flot_){}
 
 
//Methodes
void TextViewer::dessine(Systeme const& systeme)
{
    flot << systeme;
}

void TextViewer::dessine(Tissu const& tissu)
{
	flot << tissu;
}

void TextViewer::dessine(Masse const& masse)
{
	flot << masse;
}
