#include "pch.h"
#include "TextUI.h"
#include "InputManager.h"
#include "TimeManager.h"


TextUI::TextUI()
{
	//SCREEN_HEIGHT
	//SCREEN_WIDTH
	rt = { 100, 100, 500, 300 };
}

TextUI::~TextUI()
{

}

void TextUI::LateUpdate()
{

}

void TextUI::Render(HDC _hdc)
{

	DrawText(_hdc, str, -1, &rt, DT_LEFT | DT_WORDBREAK);

}

void TextUI::TextBoxOpen(LPCWSTR text)
{
	str = text;
}

void TextUI::TextBoxClose()
{
	str = TEXT("");
}
