#include "Dessinable.h"

Dessinable::Dessinable(SupportADessin* support_)
:support(support_)
{}

//Set
void Dessinable::set_support(SupportADessin* support_)
{
    support=support_;
}
