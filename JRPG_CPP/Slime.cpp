#include "Slime.h"

Slime::Slime(Stat slimeStat)
{
	stat.agility = slimeStat.agility;
	stat.armor = slimeStat.armor;
	stat.ciritalChance = slimeStat.ciritalChance;
	stat.ciritalDamage = slimeStat.ciritalDamage;
	stat.maxHealth = slimeStat.maxHealth;
	stat.strength = slimeStat.strength;

	currentHp = stat.maxHealth;

	enemyType = EnemyType::SLIME;

	nameOfEnemy = L"ΩΩ∂Û¿”";

	SetVisual();
}

void Slime::SetVisual()
{
	visual.push_back(L"         __  ");
	visual.push_back(L"       _|  |_");
	visual.push_back(L"     _|      |_");
	visual.push_back(L"    |  _    _  |");
	visual.push_back(L"    | |_|  |_| |");
	visual.push_back(L" _  |  _    _  |  _");
	visual.push_back(L"|_|_|_| |__| |_|_|_|");
	visual.push_back(L"  |_|_        _|_|");
	visual.push_back(L"    |_|______|_|");
}
