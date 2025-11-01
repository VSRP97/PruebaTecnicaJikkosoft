# PruebaTecnicaJikkosoft

## Puntos a desarrollar:
1. Diseñar un esquema de base de datos para una plataforma de blogs
**sencilla**. La plataforma debe admitir usuarios, publicaciones de blog,
comentarios y etiquetas.

2. Escribe una función en lenguaje de su preferencia que tome una lista de
enteros y un entero de destino, y devuelva los índices de los dos números
que sumados dan el resultado del entero destino.

3. Diseñe e implemente un sistema de gestión de bibliotecas sencillo con
clases para libros, bibliotecas y miembros.

## Desarrollo #1:

### Diagrama Entidad Relación
```mermaid
erDiagram
    direction TB
    us[USER]{
        guid id PK
        string username
        string email
        string password_hash
        bool active
        datetime created_at
        datetime updated_at
    }
    p[PUBLICATION]{
        guid id PK
        guid user_id FK
        string title
        string content
        datetime created_at
        datetime updated_at
    }
    c[COMMENT]{
        guid id PK
        guid user_id FK
        guid publication_id FK
        string content
        datetime created_at
        datetime updated_at
    }
    t[Tag]{
        guid id PK
        string name UK
    }
    pt[PUBLICATION_TAGS]{
        guid publication_id PK, FK
        guid tag_id PK, FK
    }
    us ||--}o p : creates
    p ||--}o c : has
    us ||--}o c : writes
    p ||..}o pt : tagged_with
    t ||..}o pt : categorized_as
```
