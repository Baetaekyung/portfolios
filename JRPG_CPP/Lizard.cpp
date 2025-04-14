#include "Lizard.h"

Lizard::Lizard(Stat lizardStat)
{
	stat.agility = lizardStat.agility;
	stat.armor = lizardStat.armor;
	stat.ciritalChance = lizardStat.ciritalChance;
	stat.ciritalDamage = lizardStat.ciritalDamage;
	stat.maxHealth = lizardStat.maxHealth;
	stat.strength = lizardStat.strength;

	currentHp = stat.maxHealth;

	enemyType = EnemyType::LIZARD;

	nameOfEnemy = L"µµ¸¶¹ì";

	SetVisual();
}

void Lizard::SetVisual()
{
	visual.push_back(L"                       )/_");
	visual.push_back(L"             _.--..---\" - ,--c_");
	visual.push_back(L"        \\L..'           ._O__)_");
	visual.push_back(L",-.     _.+  _  \\..--( /         ");
	visual.push_back(L"  `\\.-''__.-' \\ (     \\_      ");
	visual.push_back(L"    `'''       `\\__   /\\");
	visual.push_back(L"                ')");
}
