Lambdanator (λ)
===============

A teeny-tiny static reflection class.


Usage
-----

Just copy [Lambda.cs](/jagregory/lambdanator/blob/master/Lambda.cs) into your project and you're away!

You can clone this repository and build it from source if you want an assembly, or if you want to run the tests.


Examples
--------

    λ.Reflect<SomeClass>(x => x.AMethod());

    λ.Reflect<SomeClass>(x => x.AProperty);

    λ.Reflect(() => local);

If you don't like the `λ` syntax, you can use `Lambda` instead.

    Lambda.Reflect<SomeClass>(x => x.AMethod());

    Lambda.Reflect<SomeClass>(x => x.AProperty);

    Lambda.Reflect(() => local);


License
-------

New BSD, leave it at the top of the file, but otherwise do as you please just don't blame me if it blows up.