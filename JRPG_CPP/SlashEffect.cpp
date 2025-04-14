#include <io.h>
#include <fcntl.h>
#include "Console.h"
#include "SlashEffect.h"
#include "Mci.h"

void SlashEffect::PlayAnimation(int x, int y, COLOR color = COLOR::WHITE)
{
	int prevmode = _setmode(_fileno(stdout), _O_U16TEXT);
	SetColor((int)color);

	Gotoxy(x, y);
	PlayEffect(TEXT("Sounds//slash.wav"));
	for (int i = 0; i < visual->length(); i++)
	{
		wcout << visual[i] << '\n';
		Sleep(60);
	}
	SetColor((int)COLOR::WHITE);
	int curmode = _setmode(_fileno(stdout), prevmode);
}
