using ILHotfix;
namespace ILHotfix.Register
{
	public static class PatchRegister
	{
		public static void Register(IPatchInvoker patchInvoker)
		{
			Patch_TestClass_Register.Register(patchInvoker);
		}
	}
}
