# language: it
@cap5
Funzionalità: Ricerca fra i post
  Come Lettore
  Vorrei poter ricercare i post su RBlog
  Per poter navigare fra i contenuti più velocemente

  Contesto: 
    Dato apro CSBlog
    Dato mi autentico come "ttia@csblog.io"

	@clear
  Scenario: Autocompletamento della ricerca - Mini
    Dato nell'intestazione è presente la barra di ricerca
    Dato il post "Lorem Ipsum" esiste
    Quando inserisco il testo "Lorem" da ricercare
    Allora viene proposto il post "Lorem Ipsum"

  @clear
  Scenario: Autocompletamento della ricerca
    Dato nell'intestazione è presente la barra di ricerca
    Dato il post "Lorem Ipsum" esiste
    Quando inserisco il testo "Lorem" da ricercare
    Allora viene proposto il post "Lorem Ipsum"
    Quando inserisco il testo "lor" da ricercare
    Allora viene proposto il post "Lorem Ipsum"
    Quando inserisco il testo "xyz" da ricercare
    Allora non è proposto alcun post
    Quando inserisco il testo "L" da ricercare
    Allora non è proposto alcun post

  @clear
  Scenario: Ricerca di un post esistente
    Dato nell'intestazione è presente la barra di ricerca
    Dato il post "Lorem Ipsum" esiste
    Quando ricerco "Lorem"
    Allora il post "Lorem Ipsum" è leggibile
    Quando ricerco "lo"
    Allora il post "Lorem Ipsum" è leggibile

  @clear
  Scenario: Ricerca di un post non esistente
    Dato nell'intestazione è presente la barra di ricerca
    Dato il post "Lorem Ipsum" esiste
    Quando ricerco "XXX"
    Allora il post "Lorem Ipsum" non è leggibile
