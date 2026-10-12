using System.Text;

namespace MySingingMonsters
{
    internal abstract class CostumeVariant : Monster
    {
        protected CostumeVariant(
            Monster original,
            int requiredLevel,
            string attackName,
            string attackElement,
            float attackPower,
            string? replacedAttack)
        {
            baseHp = original.baseHp;
            baseAttack = original.baseAttack;
            level = original.level;
            HP = original.HP;
            Attack = original.Attack;
            isAlive = original.isAlive;
            elems = new List<Element>(original.elems);
            attacks = new List<Attack>(original.attacks);

            if (level < requiredLevel)
            {
                return;
            }

            if (replacedAttack is not null)
            {
                string normalizedReplacement = NormalizeAttackName(replacedAttack);
                attacks.RemoveAll(attack => NormalizeAttackName(attack.name) == normalizedReplacement);
            }

            attacks.Add(new Attack(attackName, new Element(attackElement), attackPower));
        }

        private static string NormalizeAttackName(string name)
        {
            var normalized = new StringBuilder(name.Length);
            foreach (char character in name)
            {
                if (char.IsLetterOrDigit(character))
                {
                    normalized.Append(char.ToLowerInvariant(character));
                }
            }

            return normalized.ToString();
        }
    }
}
