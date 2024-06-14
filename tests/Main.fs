module Tests

open Fable.Pyxpecto
open ConditionalRef

let tests = testList "tests" [
    testCase "Minimal" <| fun () ->
        let actual = Example.Minimal()
        let expected = """{"name":"Kevin","project":"ARCtrl"}"""
        Expect.equal actual expected ""
]

[<EntryPoint>]
let main argv = Pyxpecto.runTests [||] tests