namespace ConditionalRef

open Thoth.Json.Core

[<RequireQualifiedAccess>]
module Encode = 

    let inline toJsonString spaces (value : Json) = 
        #if FABLE_COMPILER_PYTHON
        Thoth.Json.Python.Encode.toString spaces value
        #endif
        #if FABLE_COMPILER_JAVASCRIPT || FABLE_COMPILER_TYPESCRIPT
        Thoth.Json.JavaScript.Encode.toString spaces value
        #endif
        #if !FABLE_COMPILER
        Thoth.Json.Newtonsoft.Encode.toString spaces value
        #endif

module Example =
    
    let Minimal() =
        let encoder = 
            Encode.object [
                "name", Encode.string "Kevin"
                "project", Encode.string "ARCtrl"
            ]
        Encode.toJsonString 0 encoder

