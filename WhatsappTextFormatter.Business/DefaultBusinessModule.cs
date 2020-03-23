using Ninject.Modules;
using WhatsappTextFormatter.Business.SimpleFormatters;

namespace WhatsappTextFormatter.Business
{
    public class DefaultBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITextFormatter>().To<BoldFormatter>();
            Bind<ITextFormatter>().To<ItalicFormatter>();
            Bind<ITextFormatter>().To<StrikeThroughFormatter>();
            Bind<ITextFormatterFactory>().To<TextFormatterFactory>();
        }
    }
}
