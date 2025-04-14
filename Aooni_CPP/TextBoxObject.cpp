#include "pch.h"
#include "TextBoxObject.h"
#include "ResourceManager.h"
#include "Texture.h"
#include "EventManager.h"
#include "TimeManager.h"
#include "Collider.h"
TextBoxObject::TextBoxObject() :
	m_tTex(nullptr)
{
	std::cout << "ming";
	this->AddComponent<Collider>();
	GetComponent<Collider>()->SetSize({ 0, 0 });
	m_tTex = GET_SINGLE(ResourceManager)->TextureFind(L"MainHole_1FScene");
}

void TextBoxObject::Render(HDC _hdc)
{
	Vec2 vPos = GetPos();
	Vec2 vSize = GetSize();

	int width = m_tTex->GetWidth();
	int height = m_tTex->GetHeight();

	::TransparentBlt(_hdc,
		static_cast<int>(vPos.x - vSize.x / 2),
		static_cast<int>(vPos.y - vSize.y / 2),
		static_cast<int>(vSize.x),
		static_cast<int>(vSize.y),
		m_tTex->GetTexDC(),
		0, 0, width, height,
		RGB(255, 0, 255));

	ComponentRender(_hdc);
}

void TextBoxObject::Update()
{
	std::cout << "\n" << cnt << "\n";
	cnt += fDT * 100;
	if (cnt >= 100) {
		bIsSpawn = false;
		GET_SINGLE(EventManager)->DeleteObject(this);
	}
}

void TextBoxObject::SetUpTextBox(TEXT_TYPE textType)
{
	wstring path;
	switch (textType)
	{
	case TEXT_TYPE::GetLiberyKey:
		path = L"GetLiberyKey";
		break;
	case TEXT_TYPE::Scare:
		path = L"Scare";
		break;
	case TEXT_TYPE::GetGlass:
		path = L"GetGlass";
		break;
	case TEXT_TYPE::ItLock:
		path = L"ItLock";
		break;
	case TEXT_TYPE::Guys:
		path = L"Guys";
		break;
	default:
		break;
	}

	m_tTex = GET_SINGLE(ResourceManager)->TextureFind(path);
}

void TextBoxObject::UPTextBox()
{
}
