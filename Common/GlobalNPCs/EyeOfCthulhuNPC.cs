using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EyeSpinEternal.Common.GlobalNPCs;

/// <summary>
/// Makes any Eye of Cthulhu-like boss spin infinitely instead of transitioning to phase 2.
/// </summary>
internal sealed class EyeOfCthulhuNPC : GlobalNPC
{
	/// <summary>
	/// The value of <see cref="EyeOfCthulhu_Phase(NPC)"/> when the Eye of Cthulhu is beginning to spin.
	/// </summary>
	private const float _eyeOfCthulhu_AccelerateSpinPhase = 1f;

	private static ref float EyeOfCthulhu_Phase(NPC eoc) => ref eoc.ai[0];

	private static ref float EyeOfCthulhu_Counter(NPC eoc) => ref eoc.ai[1];

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		// This technically applies to any EoC-like boss.
		return entity.aiStyle == NPCAIStyleID.EyeOfCthulhu;
	}

	public override void AI(NPC npc)
	{
		if (EyeOfCthulhu_Phase(npc) == _eyeOfCthulhu_AccelerateSpinPhase)
		{
			EyeOfCthulhu_Counter(npc) = 0f;
		}
	}
}