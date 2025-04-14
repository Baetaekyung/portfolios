#include <io.h>
#include "Enemy.h"
#include "Mci.h"
#include "GameManager.h"

Enemy::Enemy()
{
	enemyType = EnemyType::GOBLIN;
	nameOfEnemy = L"";
}

Enemy::Enemy(EnemyType type, Stat enemyStat, bool myTurn)
{
	this->stat.maxHealth = enemyStat.maxHealth;
	this->stat.strength = enemyStat.strength;
	this->stat.agility = enemyStat.agility;
	this->stat.armor = enemyStat.armor;
	this->stat.ciritalChance = enemyStat.ciritalChance;
	this->stat.ciritalDamage = enemyStat.ciritalDamage;

	enemyType = type;

	enemyTurn = myTurn;
	currentHp = this->stat.maxHealth;
	enemyDamage = stat.strength;

	switch (enemyType)
	{
	case EnemyType::GOBLIN:
		nameOfEnemy = L"���";
		break;
	case EnemyType::SPIDER:
		nameOfEnemy = L"�Ź�";
		break;
	case EnemyType::BEAR:
		nameOfEnemy = L"��";
		break;
	case EnemyType::LIZARD:
		nameOfEnemy = L"������";
		break;
	case EnemyType::SLIME:
		nameOfEnemy = L"������";
	default:
		break;
	}
}

void Enemy::AttackPlayer()
{
	cout << "�÷��̾ �����ߴ�.";
	GameManager::_player.Defence(enemyDamage);
}

void Enemy::GetDamage(int damage)
{
	currentHp -= damage;

	if (currentHp <= 0)
	{
		Dead();
		return;
	}
}

void Enemy::Dead()
{
	isDead = true;
}

void Enemy::Update()
{
	if (isDead) return;
	if (!enemyTurn) return;
	
	srand((unsigned int)time(NULL));
	int randNum = rand() % 2 + 1;

	switch (randNum)
	{
	case (int)Behavior::USEITEM:
	{
		UseItem();
	}
	break;
	case (int)Behavior::ATTACK:
	{
		Attack();
	}
	break;
	}

	enemyTurn = false;
}

void Enemy::Render()
{
	int prevmode = _setmode(_fileno(stdout), _O_U16TEXT);

	COORD Resolution = GetConsoleResolution();
	int x = Resolution.X / 2;
	int y = Resolution.Y / 5;
	
	if (visual.size() != 0)
	{
		for (int i = 0; i < visual.size(); i++)
		{
			Gotoxy(x - 6, y + i);
			wcout << visual[i];
		}
	}
	int curmode = _setmode(_fileno(stdout), prevmode);
}

void Enemy::Attack()
{
	srand((unsigned int)time(NULL));
	int randNum = rand() % 2 + 1;
	
	if (randNum == 1)
	{
		int critical = rand() % 100 + 1;
		if(critical < stat.ciritalChance)
		{
			enemyDamage = stat.strength;
			AttackPlayer();
		}
		else
		{
			enemyDamage = stat.strength * (1 + stat.ciritalDamage);
			AttackPlayer();
		}
	}
	else
	{
		UseSkill();
	}
}

void Enemy::Defence(int damage) // �̰� ȣ���ؼ� �������� �ֽʽÿ�!!
{
	int applyDamage = 
		(damage - stat.armor) > 1 ? (damage - stat.armor) : 1;
	GetDamage(applyDamage);
	PlayEffect(TEXT("Sounds//hitSound.wav"));
}

void Enemy::UseItem()
{
	srand((unsigned int)time(NULL));
	int randNum = rand() % 4 + 1;

	switch (randNum)
	{
	case (int)EnemyItem::HEALTHPOTION:
	{
		currentHp += 10;
		
	}
	break;
	case (int)EnemyItem::DAMAGEUPPOTION:
	{
		stat.strength += 5;
	}
	break;
	case (int)EnemyItem::AGILITYPOTION:
	{
		stat.agility += 5;
	}
	break;
	case (int)EnemyItem::ARMORPOTION:
	{
		stat.armor += 5;
	}
	break;
	}
}

void Enemy::UseSkill()
{
	srand((unsigned int)time(NULL));
	int randNum = rand() % 5 + 1;

	switch (randNum)
	{
	case (int)SkillType::DOUBLEATTACK:
	{
		AttackPlayer();
		AttackPlayer();
	}
	break;
	case (int)SkillType::ARMORUP:
	{
		stat.armor += 5;
	}
	break;
	case (int)SkillType::AGILITYUP:
	{
		stat.agility += 5;
	}
	break;
	case (int)SkillType::DAMAGEUP:
	{
		stat.strength += 5;
	}
	break;
	case (int)SkillType::HEAL:
	{
		currentHp += 5;
	}
	break;
	}
}
