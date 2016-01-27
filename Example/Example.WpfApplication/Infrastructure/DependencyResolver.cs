namespace Example.WpfApplication.Infrastructure
{
    using Ninject;
    using Ninject.Syntax;

    /// <summary>
    ///
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>();
    }

    /// <summary>
    ///
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot resolver;

        /// <summary>
        ///
        /// </summary>
        /// <param name="resolver"></param>
        public NinjectDependencyResolver(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return resolver.Get<T>();
        }
    }
}
