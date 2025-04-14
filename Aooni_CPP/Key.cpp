#include "pch.h"
#include "Key.h"
#include "Collider.h"
#include "EventManager.h"
#include "GDISelector.h"
#include "ResourceManager.h"
#include "Animator.h"
#include "PlayerManager.h"
#include "TextBoxObject.h"
#include "SceneManager.h"
#include "SpawnManger.h"
#include "Scene.h"
Key::Key() :
	MyKeyType(KEY_TYPE::None),
	currentBrushType(BRUSH_TYPE::YELLOW)
{
	m_pTex = GET_SINGLE(ResourceManager)->TextureLoad(L"Key", L"Texture\\light.bmp");

	AddComponent<Animator>();
	GetComponent<Animator>()->CreateAnimation(L"KeyAnim", m_pTex, Vec2(0.f, 0.f),
		Vec2(10.f, 10.f), Vec2(10.f, 0.f), 8, 0.1f);
	GetComponent<Animator>()->PlayAnimation(L"KeyAnim", true);

	SetName(L"Key");
	this->AddComponent<Collider>();
	GetComponent<Collider>()->SetSize({ 10, 10 });


}

Key::~Key()
{
}

void Key::Update()
{
}

void Key::Render(HDC hdc)
{
	ComponentRender(hdc);
}

void Key::EnterCollision(Collider* other)
{
	if (other->GetOwner()->GetName() == L"Player")
	{
		GET_SINGLE(SpawnManger)->Spawn({ 520, 383 },2);
		GET_SINGLE(EventManager)->DeleteObject(this);
		GET_SINGLE(PlayerManager)->AddPlayerKey(MyKeyType);
		UpTextBox();
	}
}

void Key::StayCollision(Collider* other)
{
}

void Key::ExitCollision(Collider* other)
{
}

void Key::UpTextBox()
{
	SpawnTextBox(MyTextType);
}