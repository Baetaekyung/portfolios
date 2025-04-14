#include "pch.h"
#include "Player.h"
#include "TimeManager.h"
#include "InputManager.h"
#include "Projectile.h"
#include "SceneManager.h"
#include "Scene.h"
#include "Texture.h"
#include "ResourceManager.h"
#include "Collider.h"
#include "Animator.h"
#include "Animation.h"
#include "CollisionManager.h"
#include "EventManager.h"
#include "Core.h"
Player::Player()
	: m_pTex(nullptr)
	, _speed(1.5)
	, _playerDir(Direction::DOWN)
	, canGoUpward(true)
	, canGoDownward(true)
	, canGoLeftword(true)
	, canGoRightword(true)
	, canMove(true)
	, blockdistance({ 15, 25 })
	, bIsIntro(false)
	, bCanInput(true)
{
	SetName(L"Player");

#pragma region Animation Init
	m_pTex = GET_SINGLE(ResourceManager)->TextureLoad(L"Hiroshi", L"Texture\\Hiroshi.bmp");
	this->AddComponent<Collider>();

	AddComponent<Animator>();
	GetComponent<Animator>()->CreateAnimation(L"HiroshiUpIdle", m_pTex, Vec2(0.f, 144.f),
		Vec2(32.f, 48.f), Vec2(32.f, 0.f), 1, 0.1f);
	GetComponent<Animator>()->CreateAnimation(L"HiroshiUp", m_pTex, Vec2(0.f, 144.f),
		Vec2(32.f, 48.f), Vec2(32.f, 0.f), 4, 0.1f);

	GetComponent<Animator>()->CreateAnimation(L"HiroshiDownIdle", m_pTex, Vec2(0.f, 0.f),
		Vec2(32.f, 48.f), Vec2(32.f, 0.f), 1, 0.1f);
	GetComponent<Animator>()->CreateAnimation(L"HiroshiDown", m_pTex, Vec2(0.f, 0.f),
		Vec2(32.f, 48.f), Vec2(32.f, 0.f), 4, 0.1f);

	GetComponent<Animator>()->CreateAnimation(L"HiroshiRightIdle", m_pTex, Vec2(0.f, 96.f),
		Vec2(32.f, 48.f), Vec2(32.f, 0.f), 1, 0.1f);
	GetComponent<Animator>()->CreateAnimation(L"HiroshiRight", m_pTex, Vec2(0.f, 96.f),
		Vec2(32.f, 48.f), Vec2(32.f, 0.f), 4, 0.1f);

	GetComponent<Animator>()->CreateAnimation(L"HiroshiLeftIdle", m_pTex, Vec2(0.f, 48.f),
		Vec2(32.f, 48.f), Vec2(32.f, 0.f), 1, 0.1f);
	GetComponent<Animator>()->CreateAnimation(L"HiroshiLeft", m_pTex, Vec2(0.f, 48.f),
		Vec2(32.f, 48.f), Vec2(32.f, 0.f), 4, 0.1f);

	GetComponent<Animator>()->PlayAnimation(L"HiroshiDownIdle", true);
#pragma endregion
	//Collision Check
	GET_SINGLE(CollisionManager)->GetInst()->CheckLayer(LAYER::PLAYER, LAYER::INTERACTABLE);
	GET_SINGLE(CollisionManager)->GetInst()->CheckLayer(LAYER::PLAYER, LAYER::ENEMY);
	GetComponent<Collider>()->SetSize({20.f, 35.f});
}

Player::~Player()
{

}
void Player::Update()
{
	PlayerMove();

	if (bIsIntro) {
		SetPos({ GetPos().x + 100 * _speed * fDT, GetPos().y });
	}
	/*if (GET_KEYDOWN(KEY_TYPE::SPACE))
		CreateProjectile();*/
}

void Player::Render(HDC _hdc)
{
	Vec2 vPos = GetPos();
	Vec2 vSize = GetSize();

	int width = m_pTex->GetWidth();
	int height = m_pTex->GetHeight();

	ComponentRender(_hdc);
}

void Player::StayCollision(Collider* _other)
{
	if (_other->GetOwner()->GetName() == L"Wall")
	{
		switch (_wallEnterDirection)
		{
		case Direction::LEFT:
			canGoLeftword = false;
			break;
		case Direction::RIGHT:
			canGoRightword = false;
			break;
		case Direction::UP:
			canGoUpward = false;
			break;
		case Direction::DOWN:
			canGoDownward = false;
			break;
		default:
			break;
		}
	}
}

void Player::EnterCollision(Collider* other)
{
	Interact(other);
	if (other->GetOwner()->GetName() == L"Enemy")
	{
		GET_SINGLE(EventManager)->DeleteObject(this);
		// SetDead();
		//GameOverScene Load
	}
	if (other->GetOwner()->GetName() == L"Wall")
	{
		if (GetPlayerDirection() == Direction::LEFT)
		{
			_wallEnterDirection = Direction::LEFT;
		}
		else if (GetPlayerDirection() == Direction::RIGHT)
		{
			_wallEnterDirection = Direction::RIGHT;
		}
		else if (GetPlayerDirection() == Direction::UP)
		{
			_wallEnterDirection = Direction::UP;
		}
		else if (GetPlayerDirection() == Direction::DOWN)
		{
			_wallEnterDirection = Direction::DOWN;
		}
	}
}

void Player::ExitCollision(Collider* other)
{
	if (other->GetOwner()->GetName() == L"Wall")
	{
		canGoDownward = true;
		canGoLeftword = true;
		canGoRightword = true;
		canGoUpward = true;
	}
}

bool Player::DirectionChanged(Direction direction)
{
	if (_playerDir != direction)
	{
		_playerDir = direction;
		return true;
	}
}

Direction Player::GetPlayerDirection()
{
	return _playerDir;
}

void Player::SetIntro()
{
	bCanInput = false;
	bIsIntro = true;
	GetComponent<Animator>()->PlayAnimation(L"HiroshiRight", true);
}

void Player::Interact(Collider* other)
{
	if (other->GetOwner()->GetName() == L"Key")
	{
		GET_SINGLE(ResourceManager)->Play(L"GetKey");
		keyCount++;
		cout << keyCount << '\n';
	}
	if (other->GetOwner()->GetName() == L"Door")
	{
		//Scene Change
	}
}

void Player::PlayerMove()
{
	if (!bCanInput)
		return;
	
	Vec2 vPos = GetPos();
	Vec2 vSize = GetSize();
	Vec2 colliderSize = GetComponent<Collider>()->GetSize();
	//HDC _hdc = GetDC(nullptr);
	HDC _hdc = GET_SINGLE(Core)->GetMainDC();

	if (!canMove) return;

	if (GET_KEY(KEYBOARD_TYPE::A))
	{
		color = GetPixel(_hdc, vPos.x - blockdistance.x, vPos.y);
		if (_playerDir != Direction::LEFT)
		{
			GetComponent<Animator>()->StopAnimation();
			GetComponent<Animator>()->PlayAnimation(L"HiroshiLeft", true);
			DirectionChanged(Direction::LEFT);
		}
		if (canGoLeftword) {
			vPos.x -= 100.f * fDT * _speed;
		}
	}
	else if (GET_KEY(KEYBOARD_TYPE::D))
	{
		color = GetPixel(_hdc, vPos.x + blockdistance.x, vPos.y);
		if (_playerDir != Direction::RIGHT)
		{
			GetComponent<Animator>()->StopAnimation();
			GetComponent<Animator>()->PlayAnimation(L"HiroshiRight", true);
			DirectionChanged(Direction::RIGHT);
		}
		if (canGoRightword)
			vPos.x += 100.f * fDT * _speed;
	}
	else if (GET_KEY(KEYBOARD_TYPE::S))
	{
		color = GetPixel(_hdc, vPos.x, vPos.y + blockdistance.y);
		if (_playerDir != Direction::DOWN)
		{
			GetComponent<Animator>()->StopAnimation();
			GetComponent<Animator>()->PlayAnimation(L"HiroshiDown", true);
			DirectionChanged(Direction::DOWN);
		}
		if (canGoDownward)
			vPos.y += 100.f * fDT * _speed;
	}
	else if (GET_KEY(KEYBOARD_TYPE::W))
	{
		color = GetPixel(_hdc, vPos.x, vPos.y - blockdistance.y);
		if (_playerDir != Direction::UP)
		{
			GetComponent<Animator>()->StopAnimation();
			GetComponent<Animator>()->PlayAnimation(L"HiroshiUp", true);
			DirectionChanged(Direction::UP);
		}
		if (canGoUpward)
			vPos.y -= 100.f * fDT * _speed;
	}
	else
	{
		switch (_playerDir)
		{
		case Direction::NONE:
			break;
		case Direction::LEFT:
			GetComponent<Animator>()->StopAnimation();
			GetComponent<Animator>()->PlayAnimation(L"HiroshiLeftIdle", true);
			break;
		case Direction::RIGHT:
			GetComponent<Animator>()->StopAnimation();
			GetComponent<Animator>()->PlayAnimation(L"HiroshiRightIdle", true);
			break;
		case Direction::UP:
			GetComponent<Animator>()->StopAnimation();
			GetComponent<Animator>()->PlayAnimation(L"HiroshiUpIdle", true);
			break;
		case Direction::DOWN:
			GetComponent<Animator>()->StopAnimation();
			GetComponent<Animator>()->PlayAnimation(L"HiroshiDownIdle", true);
			break;
		default:
			break;
		}
	}
	if (!IsBlockedByColor(color)) {
		SetPos(vPos);
	}
}

//void Player::CreateProjectile()
//{
//	Projectile* pProj = new Projectile;
//	Vec2 vPos = GetPos();
//	vPos.y -= GetSize().y / 2.f;
//	pProj->SetPos(vPos);
//	pProj->SetSize({30.f,30.f});
//	pProj->SetDir({0.f, -1.f});
//	pProj->SetName(L"PlayerBullet");
//
//	GET_SINGLE(SceneManager)->GetCurrentScene()->AddObject(pProj, LAYER::PROJECTILE);
//}
