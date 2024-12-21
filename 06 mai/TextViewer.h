#ifndef TEXT_VIEWER_H
#define TEXT_VIEWER_H
 
#include <iostream>
#include "SupportADessin.h"

 
class TextViewer : public SupportADessin {

	private:
	std::ostream& flot;
	
	public:
	//Constructeur / Destructeur
	TextViewer(std::ostream&);
	virtual ~TextViewer() {}
	
	//Methodes	
	virtual void dessine(Tissu   const&);
	virtual void dessine(Systeme const&);
	virtual void dessine(Masse const&);
};

#endif
