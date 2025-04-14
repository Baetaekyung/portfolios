#include "pch.h"
#include "Object.h"
#include "InputManager.h"
#include "QuestionPuzzle.h"
#include "SceneManager.h"
#include "Scene.h"
#include "Collider.h"
#include "Key.h"
#include "Player.h"
#include "EventManager.h"
#include "ResourceManager.h"
#include "Texture.h"
#include "QuizData.h"

QuestionPuzzle::QuestionPuzzle()
	: question(L"")
	, answer(L"")
	, isTriggered(false)
	, isDrawed(false)
	, isAnswerCheck(false)
	, player(nullptr)
	, currentLen(0)
	, currentChecked(3)
	, playerAnswer()
{
	//quizData = new QuizData();
	m_pTex = GET_SINGLE(ResourceManager)->TextureLoad(L"Cavinet", L"Texture\\Cavinet.bmp");
	SetSize({ 40, 45 });
	this->AddComponent<Collider>();
	GetComponent<Collider>()->SetSize(GetSize());
}

QuestionPuzzle::~QuestionPuzzle()
{
}

void QuestionPuzzle::Update()
{
	//Input check
	if (isTriggered)
	{
		if (GetAsyncKeyState(VK_BACK))
		{
			playerAnswer[0] = NULL;
			currentLen = 0;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_1))
		{
			playerAnswer[currentLen++] = '1';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_2))
		{
			playerAnswer[currentLen++] = '2';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_3))
		{
			playerAnswer[currentLen++] = '3';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_4))
		{
			playerAnswer[currentLen++] = '4';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_5))
		{
			playerAnswer[currentLen++] = '5';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_6))
		{
			playerAnswer[currentLen++] = '6';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_7))
		{
			playerAnswer[currentLen++] = '7';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_8))
		{
			playerAnswer[currentLen++] = '8';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_9))
		{
			playerAnswer[currentLen++] = '9';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::NUM_0))
		{
			playerAnswer[currentLen++] = '0';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::Q))
		{
			playerAnswer[currentLen++] = 'q';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::W))
		{
			playerAnswer[currentLen++] = 'w';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::E))
		{
			playerAnswer[currentLen++] = 'e';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::R))
		{
			playerAnswer[currentLen++] = 'r';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::T))
		{
			playerAnswer[currentLen++] = 't';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::Y))
		{
			playerAnswer[currentLen++] = 'y';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::U))
		{
			playerAnswer[currentLen++] = 'u';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::I))
		{
			playerAnswer[currentLen++] = 'i';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::O))
		{
			playerAnswer[currentLen++] = 'o';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::P))
		{
			playerAnswer[currentLen++] = 'p';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::A))
		{
			playerAnswer[currentLen++] = 'a';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::S))
		{
			playerAnswer[currentLen++] = 's';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::D))
		{
			playerAnswer[currentLen++] = 'd';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::F))
		{
			playerAnswer[currentLen++] = 'f';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::G))
		{
			playerAnswer[currentLen++] = 'g';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::H))
		{
			playerAnswer[currentLen++] = 'h';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::J))
		{
			playerAnswer[currentLen++] = 'j';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::K))
		{
			playerAnswer[currentLen++] = 'k';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::L))
		{
			playerAnswer[currentLen++] = 'l';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::Z))
		{
			playerAnswer[currentLen++] = 'z';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::X))
		{
			playerAnswer[currentLen++] = 'x';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::C))
		{
			playerAnswer[currentLen++] = 'c';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::V))
		{
			playerAnswer[currentLen++] = 'v';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::B))
		{
			playerAnswer[currentLen++] = 'b';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::N))
		{
			playerAnswer[currentLen++] = 'n';
			playerAnswer[currentLen] = NULL;
		}
		if (GET_KEYDOWN(KEYBOARD_TYPE::M))
		{
			playerAnswer[currentLen++] = 'm';
			playerAnswer[currentLen] = NULL;
		}
	}

	if (isAnswerCheck)
	{
		if (GET_KEYDOWN(KEYBOARD_TYPE::ENTER))
		{
			question = answer + L" " + errorMessage;
		}
	}
	if (GET_KEYDOWN(KEYBOARD_TYPE::ENTER))
	{
		if (isTriggered) 
		{
			if (playerAnswer == answer)
			{
				cout << "answer!";
				if (player != nullptr)
				{
					player->SetMove(true);
					Vec2 playerNextPos{ player->GetPos().x,
						player->GetPos().y + GetSize().y };
					player->SetPos(playerNextPos);
					GET_SINGLE(EventManager)->DeleteObject(this);
				}
				Key* key = new Key;
				key->SetPos(GetPos());
				key->SetName(L"Key");
				GET_SINGLE(SceneManager)->GetCurrentScene()->AddObject(key, LAYER::INTERACTABLE);
			}
			else
			{
				if (player != nullptr)
				{
					player->SetMove(true);
					Vec2 playerNextPos{ player->GetPos().x,
						player->GetPos().y + GetSize().y };
					player->SetPos(playerNextPos);
					currentChecked--;
				}
			}

			playerAnswer[0] = NULL;
			currentLen = 0;
		}
		isDrawed = false;
		isTriggered = false;
	}
}

void QuestionPuzzle::Render(HDC hdc)
{
	SetTextColor(hdc, RGB(255, 0, 0));
	SetBkColor(hdc, TRANSPARENT);
	if(isTriggered)
	{
		TextOut(hdc, 550, 600, question.c_str(),
			question.size());
		TextOut(hdc, 550, 650, playerAnswer, 
			wcslen(playerAnswer));
		isDrawed = true;
	}
	BitBlt(hdc, GetPos().x - 20, GetPos().y - 25, 
		GetSize().x, GetSize().y,
		m_pTex->GetTexDC(), 0, 0, SRCCOPY);
	ComponentRender(hdc);
}

void QuestionPuzzle::EnterCollision(Collider* other)
{
	if (isDrawed) return;

	if (other->GetOwner()->GetName() == L"Player")
	{
		if (currentChecked == 0)
		{
			isAnswerCheck = true;
			question = L"Enter to check answer!";
		}

		cout << "trigger!";
		player = dynamic_cast<Player*>(other->GetOwner());
		player->SetMove(false);
		
		isTriggered = true;
	}
}

void QuestionPuzzle::ExitCollision(Collider* other)
{
	if (other->GetOwner()->GetName() == L"Player")
	{
		playerAnswer[0] = NULL;
		
		isDrawed = false;
		isTriggered = false;
	}
}

void QuestionPuzzle::SetQuiz(QuizEnum quiz)
{
	/*question = quizData->quizs[quiz].question;
	errorMessage = quizData->quizs[quiz].errorMessage;
	answer = quizData->quizs[quiz].answer;*/
}
