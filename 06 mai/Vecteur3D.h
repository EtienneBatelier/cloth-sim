#ifndef PRJ_VECTEUR3D_H
#define PRJ_VECTEUR3D_H
#include <iostream>
#include <array>
#include <cmath>
typedef std::array<double,3> vecteur; 

class Vecteur3D
{
	vecteur v;
	public:
	//Gets
	vecteur get_vecteur() const;
	//Sets
	void set_coord(int const&,double const&);
	void set_vecteur(double const&,double const&,double const&);
	//Fonctions
	void affiche(std::ostream& =std::cout) const;
	bool compare(Vecteur3D const&) const;
	Vecteur3D addition(Vecteur3D const&) const;
	Vecteur3D soustraction(Vecteur3D const&) const;
	Vecteur3D oppose() const;
	Vecteur3D mult(double const&) const;
	double prod_scal(Vecteur3D const&) const;
	Vecteur3D prod_vect(Vecteur3D const&) const;
	double norme2() const;
	double norme() const;
	bool est_colineaire(Vecteur3D const&) const;
	bool est_perpendiculaire(Vecteur3D const&) const;
	//Constructeurs
	Vecteur3D();
	Vecteur3D(double const&,double const&,double const&);
	//Operateurs
	Vecteur3D operator+=(Vecteur3D const&);
	Vecteur3D operator-=(Vecteur3D const&);
	Vecteur3D operator^=(Vecteur3D const&);
	Vecteur3D operator*=(double const&);
	Vecteur3D operator-();
};
//Operateurs
bool operator==(Vecteur3D const&,Vecteur3D const&);
Vecteur3D operator+(Vecteur3D const&,Vecteur3D const&);
Vecteur3D operator-(Vecteur3D const&,Vecteur3D const&);
double operator*(Vecteur3D const&,Vecteur3D const&);
Vecteur3D operator^(Vecteur3D const&,Vecteur3D const&);
Vecteur3D operator*(double const&,Vecteur3D const&);
Vecteur3D operator*(Vecteur3D const&,double const&);
std::ostream& operator<<(std::ostream&,Vecteur3D  const&);
#endif // PRJ_VECTEUR3D_H
