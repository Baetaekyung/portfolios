#include "pch.h"
#include "QuizData.h"

QuizData::QuizData()
{
	quizs.insert({ QuizEnum::MOTIVE, quiz1 });
	quizs.insert({ QuizEnum::MATH, quiz2 });
	quizs.insert({ QuizEnum::NONSENSE, quiz3 });
	quizs.insert({ QuizEnum::NONSENSE2, quiz4 });
	quizs.insert({ QuizEnum::NONSENSE3, quiz5 });
}

QuizData::~QuizData()
{
	quizs.clear();
}
