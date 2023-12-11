using FitnessApp.UI.Dialog;
using FitnessApp.Data.DBContext;

using (FitnessAppContext context = new FitnessAppContext())
{
    context.Database.EnsureCreated();
}

new UserDialog().StartLogonDialog();
