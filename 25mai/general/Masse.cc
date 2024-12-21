#include "Ressort.h"
using namespace std;

//Gets
Vecteur3D Masse::get_position() const{
	return position;
}

Vecteur3D Masse::get_vitesse() const{
	return vitesse;
}

Vecteur3D Masse::get_force_subie() const{
	return force_subie;
}

double Masse::get_m() const{
	return m;
}

double Masse::get_lambda() const{
	return lambda;
}

vector<Ressort*> Masse::get_ressorts_associes() const{
    return ressorts_associes;
}

//Sets
void Masse::set_position(Vecteur3D const& V)
{position=V;}

void Masse::set_vitesse(Vecteur3D const& V)
{vitesse=V;}

void Masse::set_force_subie(Vecteur3D const& V)
{force_subie=V;}

void Masse::set_m(double const& a)
{m=a;}

void Masse::set_lambda(double const& a)
{lambda=a;}

//Fonctions
void Masse::ajoute_force(Vecteur3D const& df){
	force_subie += df;
}

Vecteur3D Masse::acceleration() const{
	return force_subie*(1.0/m);
}

/*void Masse::mise_a_jour_forces(){
	Vecteur3D g(0.0, 0.0, -9.81);
	force_subie = (g*m)-(vitesse*lambda);
	cout<<"force_subie : "<<force_subie;
	for (auto r : ressorts_associes)
	{
		ajoute_force((*r).force_rappel(this));
		force_subie = (g*m)-(vitesse*lambda);
	}
}*/

void Masse::mise_a_jour_forces(){
	Vecteur3D g(0.0, 0.0, -9.81);
	force_subie = (g*m);
	for (auto r : ressorts_associes)
	{
		force_subie+=(*r).force_rappel(this);
	}
	force_subie-=(vitesse*lambda);
}

//Constructeurs
Masse::Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_,SupportADessin* support_)
:m(m_), lambda(lambda_), position(position_), vitesse(vitesse_),ressorts_associes(ressorts_associes_),Dessinable(support_)
{
	force_subie=Vecteur3D(0.0, 0.0, -9.81*m);
}

Masse::Masse(double const& m_,SupportADessin* support_)
:m(m_), lambda(0.0),Dessinable(support_)
{
	force_subie=Vecteur3D(0.0, 0.0, -9.81*m);
}

void Masse::affiche(ostream& sortie) const{
	sortie << "affichage de Masse : " << endl
	<< m << " # m" << endl 
	<< lambda << " # lambda" << endl
	<< position << " # position" << endl
	<< vitesse << " # vitesse" << endl
	<< force_subie << " # force_subie" << endl
	<< ressorts_associes.size()
	<< " # nombre de ressort(s) associé(s) " << endl;
	for(size_t i(0);i<ressorts_associes.size();i++)
	{
		sortie<<ressorts_associes[i]<<endl;
	}
}
//Actions sur les ressorts
void Masse::attache_ressort(Ressort* ressort){
	//~ cout << "Le ressort " << ressort << " est connecte a la masse " << this << endl;
	ressorts_associes.push_back(ressort);
}
void Masse::clear_ressorts(){
	ressorts_associes.clear();
}

bool Masse::chercher_ressort(const Ressort* r_) const{
	for (auto r : ressorts_associes)
	{
		if (r==r_)
		{
			return true;
		}
	}
	return false;
}

bool Masse::seule() const{
	return (ressorts_associes.size()==0);
}

bool Masse::ressortsOK() const{
	int compteur(0);
	for (auto r : ressorts_associes)
	{
		++compteur;
		if (r->chercher_masse(this) == false)
		{
			cerr << "La masse d'adresse " << this << ", reliee au ressort " << compteur << ", d'adresse "<< r << " n'apparait pas dans la collection de masses de ce ressort." << endl;
			return false;
		}
	}
	return true;
}
//Dessine
void Masse::dessine() const
{support->dessine(*this);}

//Opérateurs
ostream& operator<<(ostream& sortie, Masse const& masse){
	masse.affiche(sortie);
	return sortie;
}
