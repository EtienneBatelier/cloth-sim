#include "Vecteur3D.h"

using namespace std;

//Gets
vecteur Vecteur3D::get_vecteur() const
{
	return v;
}

//Sets
void Vecteur3D::set_coord(int const& a,double const& b)
{
	v[a]=b;
}
void Vecteur3D::set_vecteur(double const& a,double const& b,double const& c)
{
	v[0]=a;
	v[1]=b;
	v[2]=c;
}
//Fonctions
void Vecteur3D::affiche(ostream& sortie) const
{
	sortie<<"("<<v[0]<<","<<v[1]<<","<<v[2]<<")";
}

bool Vecteur3D::compare(Vecteur3D const& V) const
{
	for(int i(0);i<3;i++)
	{
		if(v[i]!=V.get_vecteur()[i]) return false;
	}
	return true;
}

Vecteur3D Vecteur3D::addition(Vecteur3D const& V) const
{
	Vecteur3D R;
	vecteur w(V.get_vecteur());
	R.set_vecteur(v[0]+w[0],v[1]+w[1],v[2]+w[2]);
	return R;
}
Vecteur3D Vecteur3D::soustraction(Vecteur3D const& V) const
{
	Vecteur3D R;
	vecteur w(V.get_vecteur());
	return addition(V.oppose());
}
Vecteur3D Vecteur3D::oppose() const
{
	Vecteur3D R;
	R.set_vecteur(-1.0*v[0],-1.0*v[1],-1.0*v[2]);
	return R;
}
Vecteur3D Vecteur3D::mult(double const& a) const
{
	Vecteur3D R;
	R.set_vecteur(a*v[0],a*v[1],a*v[2]);
	return R;
}

double Vecteur3D::prod_scal(Vecteur3D const& V) const
{
	vecteur w(V.get_vecteur());
	return v[0]*w[0]+v[1]*w[1]+v[2]*w[2];
}
Vecteur3D Vecteur3D::prod_vect(Vecteur3D const& V) const
{
	Vecteur3D R;
	vecteur w(V.get_vecteur());
	R.set_vecteur(v[1]*w[2]-v[2]*w[1],v[2]*w[0]-v[0]*w[2],v[0]*w[1]-v[1]*w[0]);
	return R;
}
double Vecteur3D::norme2() const
{
	return prod_scal(*this);
}
double Vecteur3D::norme() const
{
	return sqrt(norme2());
}

//Constructeurs
Vecteur3D::Vecteur3D(double const& a,double const& b,double const& c)
:v({a,b,c})
{}

Vecteur3D::Vecteur3D()
:Vecteur3D(0.0,0.0,0.0)
{}

//Operateurs
bool operator==(Vecteur3D const& V1,Vecteur3D const& V2)
{
	return V1.compare(V2);
}

ostream& operator<<(ostream& sortie,Vecteur3D  const& V1)
{
	V1.affiche(sortie);
	return sortie;
}


//Operateurs Algébriques
Vecteur3D operator+(Vecteur3D const& V1,Vecteur3D const& V2)
{return V1.addition(V2);}

Vecteur3D operator-(Vecteur3D const& V1,Vecteur3D const& V2)
{return V1.soustraction(V2);}

double operator*(Vecteur3D const& V1,Vecteur3D const& V2)
{return V1.prod_scal(V2);}

Vecteur3D operator^(Vecteur3D const& V1,Vecteur3D const& V2)
{return V1.prod_vect(V2);}

Vecteur3D Vecteur3D::operator+=(Vecteur3D const& V1)
{
	(*this)=(*this)+V1;
	return *this;
}

Vecteur3D Vecteur3D::operator-=(Vecteur3D const& V1)
{
	(*this)=(*this)-V1;
	return *this;
}

Vecteur3D Vecteur3D::operator^=(Vecteur3D const& V1)
{
	(*this)=(*this)^V1;
	return *this;
}

Vecteur3D operator*(double const& a, Vecteur3D const& V1)
{return V1.mult(a);}

Vecteur3D operator*(Vecteur3D const& V1,double const& a)
{return V1.mult(a);}

Vecteur3D Vecteur3D::operator*=(double const& a)
{return (*this)*a;}

Vecteur3D Vecteur3D::operator-()
{return (*this).oppose();}
