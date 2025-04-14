#include "pch.h"
#include "PlayerManager.h"
#include "vector"

bool PlayerManager::GetPlayerKey(KEY_TYPE findKey)
{
	for (auto key : Keylist) {
		if (key == findKey)
			return true;
	}
	return false;
}

void PlayerManager::AddPlayerKey(KEY_TYPE newKeyType)
{
	Keylist.push_back(newKeyType);
}
