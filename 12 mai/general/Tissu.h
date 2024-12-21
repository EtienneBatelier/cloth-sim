#ifndef PRJ_TISSU_H
#define PRJ_TISSU_H
#include "Ressort.h"
#include "Integrateur.h"
#include "Dessinable.h"

class Tissu : public Dessinable
{
	private : 
	std::vector<Masse*> masses;
	std::vector<Ressort> ressorts;
	
	void connecte(size_t, size_t, double, double);
	void connecte_masses();
	
	public :
    //Set
    void set_support(SupportADessin* support_);
	//Constructeur
    Tissu(std::vector<Masse*> const& ,SupportADessin* = nullptr);
	//Destructeur
	~Tissu() {}
	//Gets
	std::vector<Masse> get_masses() const;
	std::vector<Ressort> get_ressorts() const;
	//Fonctions
	bool check() const;
	void mise_a_jour_forces();
	void evolue(Integrateur&, double);
	void affiche(std::ostream&) const;
	void ajoute_force(Vecteur3D);
    void compenser_poids();
	//Dessine
	void dessine() const override;
	//Fonction EPHEMERE (existe deja en prive mais utile pour TestTissu1 et 2)
	void connecte2(size_t, size_t, double, double);
	void connecte_masses2();

	
};
//Operateur d'affichage
std::ostream& operator<<(std::ostream& sortie, Tissu const& tissu);

#endif
