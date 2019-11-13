#ifndef _DARMARK_PLUGIN_ARGUMENT_
#define _DARMARK_PLUGIN_ARGUMENT_

#include "../types/darmark_types.h"

struct plugin_argument
{
	char* Name;
	darmark_type Type;
	void* Value;
}

#endif
