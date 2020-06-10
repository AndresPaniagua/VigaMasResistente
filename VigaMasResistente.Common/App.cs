using MvvmCross.IoC;
using MvvmCross.ViewModels;
using VigaMasResistente.Common.ViewModels;

namespace VigaMasResistente.Common
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<VigaViewModel>();
        }
    }
}