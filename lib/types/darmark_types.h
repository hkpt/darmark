#ifndef _DARMARK_TYPES_
#define _DARKARK_TYPES_

typedef struct{
	long TypeIdentifier;
}darmark_type;

/*
 * Darmark Basic Type Definitions - This may expand later
 * */

#define UNSIGNED_LONG	  0b00000001
#define UNSIGNED_FLOAT	0b00000010
#define SIGNED_LONG		  0b00000100
#define SIGNED_FLOAT		0b00001000
#define STRING		      0b00010000

 /*
  * Below are some checker functions - these are for the plugins to be able to safely cast
  * */

bool is_unsigned_long(darmark_type type);

bool is_unsigned_float(darmark_type type);

bool is_signed_long(darmark_type type);

bool is_signed_float(darmark_type type);

bool is_string(darmark_type type);

#endif
