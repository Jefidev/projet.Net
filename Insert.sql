BEGIN
	INSERT INTO DEFAUTS (PHOTO, DESCRIPTION, POSITION, DATEDEFAUT) VALUES (NULL, 'Nid de poule à Verviers', '(50.584233;5.896729)', '2015-11-15');
	UPDATE DEFAUTS SET Photo = (SELECT BulkColumn FROM Openrowset(Bulk 'C:\Users\Utilisateur\Desktop\projet.Net\Photos\1.jpg', Single_Blob) as Picture) WHERE IDDEFAUT = 1;
	INSERT INTO DEFAUTS (PHOTO, DESCRIPTION, POSITION, DATEDEFAUT) VALUES (NULL, 'Racine d''abre déformant le trottoir à Seraing', '(50.612741;5.509344)', '2015-11-20');
	UPDATE DEFAUTS SET PHOTO = (SELECT BulkColumn FROM Openrowset(Bulk 'C:\Users\Utilisateur\Desktop\projet.Net\Photos\2.jpg', Single_Blob) as Picture) WHERE IDDEFAUT = 2;
	-- LES CHEMINS POUR LES PHOTOS SONT MIS PAR RAPPORT A MON ORDI, JE NE SAIS PAS OU T'AS PLACE TON CLONE DU REPO GIT

	INSERT INTO PERSONNES (MAIL, PASSWORD, NOM, PRENOM, TYPE) VALUES ('oce@gmail.com', 'oce', 'SEEL', 'Océane', 'CHEF');
	INSERT INTO PERSONNES (MAIL, PASSWORD, NOM, PRENOM, TYPE) VALUES ('je@gmail.com', 'je', 'FINK', 'Jérôme', 'OUVRIER');

	INSERT INTO INTERVENTIONS (ETAT, COMMENTAIRE, DATEINTERVENTION, IDDEFAUT, MAIL) VALUES('OUVERT', 'Problème ouvert', '2015-11-15', 1, NULL);
	INSERT INTO INTERVENTIONS (ETAT, COMMENTAIRE, DATEINTERVENTION, IDDEFAUT, MAIL) VALUES('EN TRAITEMENT', 'Assignation d''un ouvrier (je@gmail.com)', '2015-11-15', 1, 'oce@gmail.com');
	INSERT INTO INTERVENTIONS (ETAT, COMMENTAIRE, DATEINTERVENTION, IDDEFAUT, MAIL) VALUES('EN TRAITEMENT', 'Assignation d''un ouvrier (par oce@gmail.com)', '2015-11-15', 1, 'je@gmail.com');
	INSERT INTO INTERVENTIONS (ETAT, COMMENTAIRE, DATEINTERVENTION, IDDEFAUT, MAIL) VALUES('OUVERT', 'Problème ouvert', '2015-11-20', 2, NULL);
	INSERT INTO INTERVENTIONS (ETAT, COMMENTAIRE, DATEINTERVENTION, IDDEFAUT, MAIL) VALUES('A VALIDER', 'Réparations finies, à valider', '2015-11-18', 1, 'je@gmail.com');

END;

-- DELETE FROM Interventions WHERE IdIntervention = 29 OR IdIntervention = 30 OR IdIntervention = 31;

-- INSERT INTO DEFAUTS(Col1, Col2, Col3, Photo)
-- SELECT ValCol1, ValCol2, ValCol3, BulkColumn
-- FROM Openrowset(Bulk 'C:\Users\Utilisateur\Desktop\projet.Net\Photos\1.jpg', Single_Blob) as Picture