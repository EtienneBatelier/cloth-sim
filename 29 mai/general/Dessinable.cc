#include "Dessinable.h"

//Constructeur
Dessinable::Dessinable(SupportADessin* support_)
:support(support_)
{}

//Destructeur
/*Dessinable::~Dessinable()
{
    if(support!=nullptr)
    {delete support;}
}*/

//Set
void Dessinable::set_support(SupportADessin* support_)
{
    support=support_;
}
