CREATE TABLE "tr_role" (
	"role_id" INTEGER NOT NULL DEFAULT E'',
	"role_name" VARCHAR(150) NULL DEFAULT NULL,
	PRIMARY KEY ("role_id")
)
;
COMMENT ON COLUMN "tr_role"."role_id" IS E'';
COMMENT ON COLUMN "tr_role"."role_name" IS E'';

/*================*/
CREATE TABLE "tr_user" (
	"user_id" INTEGER NOT NULL DEFAULT E'',
	"user_name" VARCHAR(200) NULL DEFAULT NULL,
	"email" VARCHAR(300) NULL DEFAULT NULL,
	"full_name" VARCHAR(400) NULL DEFAULT NULL,
	"password" VARCHAR(150) NULL DEFAULT NULL,
	PRIMARY KEY ("user_id")
)
;
COMMENT ON COLUMN "tr_user"."user_id" IS E'';
COMMENT ON COLUMN "tr_user"."user_name" IS E'';
COMMENT ON COLUMN "tr_user"."email" IS E'';
COMMENT ON COLUMN "tr_user"."full_name" IS E'';
COMMENT ON COLUMN "tr_user"."password" IS E'';


/*================*/
CREATE TABLE "tt_user_role" (
	"user_id" INTEGER NOT NULL,
	"role_id" INTEGER NOT NULL,
	PRIMARY KEY ("user_id", "role_id")
)
;
COMMENT ON COLUMN "tt_user_role"."user_id" IS E'';
COMMENT ON COLUMN "tt_user_role"."role_id" IS E'';

/*================*/
 SELECT u.user_name,
    u.email,
    u.full_name,
    r.role_name
   FROM ((tr_user u
     JOIN tt_user_role ur ON ((u.user_id = ur.user_id)))
     JOIN tr_role r ON ((ur.role_id = r.role_id)));