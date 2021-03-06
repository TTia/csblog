# language: it
@cap6
Funzionalità: Autenticazione su SBlog
  Come Autore di SBlog
  Vorrei che alcune operazioni sensibili siano permesse previa autenticazione
  Per poter garantire l'autenticità dei contenuti

  Contesto: 
    Dato apro CSBlog

  Scenario: Possibilità di autenticarsi
    Dato l'utente non è autenticato
    Allora tramite l'intestazione posso autenticarmi

  Scenario: Autenticazione su SBlog
    Dato l'utente non è autenticato
    Allora tramite l'intestazione posso autenticarmi
    Quando mi autentico come "ttia@csblog.io"
    Allora l'utente è autenticato
    E tramite l'intestazione non posso autenticarmi
    E tramite l'intestazione posso disconnettermi

  Scenario: Disconnessione da CSBlog
    Dato l'utente non è autenticato
    Quando mi autentico come "ttia@csblog.io"
    Allora tramite l'intestazione posso disconnettermi
    Quando quando mi disconnetto
    Allora tramite l'intestazione posso autenticarmi

  Scenario: Possibilità di compiere operazioni sensibili avendo compiuto l'accesso
    Dato l'utente non è autenticato
	Allora non posso visitare la pagina per la creazione di un nuovo post
    Quando mi autentico come "ttia@csblog.io"
    Allora posso navigare verso la pagina per la creazione di un nuovo post

  Scenario: Autenticazione fallita su SBlog
    Dato l'utente non è autenticato
    Allora tramite l'intestazione posso autenticarmi
    Quando mi autentico come "anonymous@csblog.io"
    Allora compare l'errore di autenticazione "Credenziali invalide."
