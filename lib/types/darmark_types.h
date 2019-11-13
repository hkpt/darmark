#ifndef _DARMARK_TYPES_
#define _DARKARK_TYPES_

typedef struct{
	long TypeIdentifier;
}darmark_type;

/*
 * Darmark Basic Type Definitions - This may expand later
 * */

const long UNSIGNED_LONG	0b00000001
const long UNSIGNED_FLOAT	0b00000010
const long SIGNED_LONG		0b00000100
const long SIGNED_FLOAT		0b00001000
const long STRING		0b00010000

 /*
  * Below are some checker functions - these are for the plugins to be able to safely cast
  * */

bool is_unsigned_long(darmark_type type);

bool is_unsigned_float(darmark_type type);

bool is_signed_long(darmark_type type);

bool is_signed_float(darmark_type type);

bool is_string(darmark_type type);

#endif
