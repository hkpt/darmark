#ifndef _DARMARK_PLUGIN_MANAGER_
#define _DARMARK_PLUGIN_MANAGER_

#include "plugin.h"
#include "plugin_type.h"

struct plugins* load_plugins(DIR directory);

struct plugin get_plugin_by_name(char* name);

void list_plugins(struct plugin_type type);

void close_plugins_by_type(struct plugin_type type);

void close_plugin_by_name(char* name);

void close_all_plugins();

#endif
