#include "Spider.h"
#include "Console.h"

Spider::Spider(Stat enemyStat)
{
	stat.agility = enemyStat.agility;
	stat.armor = enemyStat.armor;
	stat.ciritalChance = enemyStat.ciritalChance;
	stat.ciritalDamage = enemyStat.ciritalDamage;
	stat.maxHealth = enemyStat.maxHealth;
	stat.strength = enemyStat.strength;

	currentHp = stat.maxHealth;

	enemyType = EnemyType::SPIDER;

	nameOfEnemy = L"°Å¹Ì";

	SetVisual();
}

void Spider::SetVisual()
{
	visual.push_back(L" ||  ||");
	visual.push_back(L" \\()//");
	visual.push_back(L"//(__)\\");
	visual.push_back(L"||    ||");
}
