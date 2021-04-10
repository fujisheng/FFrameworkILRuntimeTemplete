using ILHotfix;
namespace ILHotfix.Register
{
	public static class Patch_TestClass_Register
	{
		static IPatchInvoker PatchInvoker;
		public static void Register(IPatchInvoker patchInvoker)
		{
			PatchInvoker = patchInvoker;
			Register_Add();
		}
		static void Register_Add()
		{
			Patch.Reginster("TestClass.Add", (t, m, i, a)=>{
				PatchInvoker.Invoke("TestClass_Hotfix", "SetTarget", null, i);
				return PatchInvoker.Invoke("TestClass_Hotfix", m, null, a);
			});
		}
	}
}
