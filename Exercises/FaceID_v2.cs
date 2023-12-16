using System;
using System.Collections.Generic;

public class FacialFeatures
{
  public string EyeColor { get; }
  public decimal PhiltrumWidth { get; }

  public FacialFeatures(string eyeColor, decimal philtrumWidth)
  {
    EyeColor = eyeColor;
    PhiltrumWidth = philtrumWidth;
  }

  public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
  public string Email { get; }
  public FacialFeatures FacialFeatures { get; }

  public Identity(string email, FacialFeatures facialFeatures)
  {
    Email = email;
    FacialFeatures = facialFeatures;
  }

  public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
  private readonly HashSet<int> _registered = new HashSet<int>();

  public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) =>
      faceA.GetHashCode().Equals(faceB.GetHashCode());

  public bool IsAdmin(Identity identity)
  {
    var adminIdentity = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    return identity.GetHashCode() == adminIdentity.GetHashCode();
  }

  public bool Register(Identity identity) => _registered.Add(identity.GetHashCode());

  public bool IsRegistered(Identity identity) => _registered.Contains(identity.GetHashCode());

  public static bool AreSameObject(Identity identityA, Identity identityB) =>
      ReferenceEquals(identityA, identityB);
}