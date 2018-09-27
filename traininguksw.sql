CREATE TABLE tr_role (
	role_id SERIAL NOT NULL,
	role_name VARCHAR(150) NULL DEFAULT NULL,
	PRIMARY KEY (role_id)
);

/*================*/
CREATE TABLE tr_user (
	user_id SERIAL NOT NULL ,
	user_name VARCHAR(200) NULL DEFAULT NULL,
	email VARCHAR(300) NULL DEFAULT NULL,
	full_name VARCHAR(400) NULL DEFAULT NULL,
	password VARCHAR(150) NULL DEFAULT NULL,
	PRIMARY KEY (user_id)
)
;

/*================*/
CREATE TABLE tt_user_role (
	user_id INTEGER NOT NULL,
	role_id INTEGER NOT NULL,
	PRIMARY KEY (user_id, role_id)
);

ALTER TABLE tt_user_role add FOREIGN KEY (user_id) REFERENCES tr_user(user_id); 
ALTER TABLE tt_user_role add FOREIGN KEY (role_id) REFERENCES tr_role(role_id);

/*================*/
 create view vw_user_role as
SELECT u.user_name,
    u.email,
    u.full_name,
    r.role_name
   FROM ((tr_user u
     JOIN tt_user_role ur ON ((u.user_id = ur.user_id)))
     JOIN tr_role r ON ((ur.role_id = r.role_id)));