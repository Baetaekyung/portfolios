#include "Enemy.h"
#include "Bear.h"

Bear::Bear(Stat bearStat)
{
	stat.maxHealth = bearStat.maxHealth;
	stat.strength = bearStat.strength;
	stat.agility = bearStat.agility;
	stat.armor = bearStat.armor;
	stat.ciritalChance = bearStat.ciritalChance;
	stat.ciritalDamage = bearStat.ciritalDamage;

	currentHp = stat.maxHealth;

	enemyType = EnemyType::BEAR;

	nameOfEnemy = L"°õ";

	SetVisual();
}

void Bear::SetVisual()
{
	visual.push_back(L"__         __");
	visual.push_back(L" / \\. - \"\"\"-./  \"");
	visual.push_back(L"\\    -    -    /");
	visual.push_back(L" |   o   o     | ");
	visual.push_back(L" \\  . - '''-. /");
	visual.push_back(L"  '-\\__Y__/-'");
	visual.push_back(L"     `---`");
}
