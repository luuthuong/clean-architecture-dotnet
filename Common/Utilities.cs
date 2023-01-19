using System.Reflection;

namespace Common
{
    public static class Utilities
    {
        public static IEnumerable<Assembly> GetAssembliesOfType(params Type[] type) {
            return AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(GetLoadableTypes)
                            .Where(x => type.Any(y => y.IsAssignableFrom(x)))
                            .Select(Assembly.GetAssembly)
                            .Distinct().ToList();
        }
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if(assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(type => type != null);
            }
        }
    }
}