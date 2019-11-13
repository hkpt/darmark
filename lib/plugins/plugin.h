#ifndef _DARMARK_PLUGIN_
#define _DARMARK_PLUGIN_

#include "plugin_type.h"
#include "plugin_argument.h"

struct plugin
{
	char* Name;
	void* Execute(struct plugin_argument* plugin_arguments);
}

#endif
